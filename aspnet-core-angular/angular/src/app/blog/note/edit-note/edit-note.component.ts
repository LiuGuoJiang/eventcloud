import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { NoteServiceProxy, NoteDto, UpdateNoteDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import marked from 'marked';
import { FormControl } from '@angular/forms';
import 'rxjs/add/operator/debounceTime';  // 触发间隔
import 'rxjs/add/operator/distinctUntilChanged'; // 防止触发两次


@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.css']
})
export class EditNoteComponent extends AppComponentBase {
  active = false; // 弹出层内容是否有效
  note: UpdateNoteDto; // 编辑的文章
  preViewContent = ''; // 文章预览内容，转换层html后的
  @ViewChild('editNoteModal') modal: ModalDirective;  // 弹出层
  @ViewChild('modalContent') modalContent: ElementRef; // 弹出层内的内容
  term = new FormControl();

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>(); // 页面间传值，这相当于一个自定义事件
  constructor(injector: Injector, private noteServer: NoteServiceProxy) {
    super(injector);
  }
  // 显示
  show(id: number): void {
    this.noteServer.getNote(id).subscribe(m => {
      this.note = m;
      this.active = true;
      this.modal.show();
      this.term.valueChanges  // 监测输入文本框的变化同步更新预览 400ms
        .debounceTime(400)
        .distinctUntilChanged()
        .subscribe(term => {
          this.preViewContent = marked(this.note.content);
        });
      this.term.valueChanges  // 30s自动保存到服务器
        .debounceTime(1000 * 30)
        .subscribe(t => this.updateNote());
    });
  }
  // 关闭
  close(): void {
    this.updateNote();
    this.active = false;
    this.modal.hide();
    this.modalSave.emit(this.note.title);//这里还可以传一个值
  }

  // 更新
  updateNote(): void {
    this.noteServer.update(this.note).subscribe(m => {

    });
  }

}