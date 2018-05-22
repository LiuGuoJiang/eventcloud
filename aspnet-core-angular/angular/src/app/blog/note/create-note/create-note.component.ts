import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { NoteServiceProxy, CreateNoteDto, NoteDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import marked from 'marked';
import { FormControl } from '@angular/forms';
import 'rxjs/add/operator/debounceTime';  // 触发间隔
import 'rxjs/add/operator/distinctUntilChanged'; // 防止触发两次

@Component({
  selector: 'create-note-note',
  templateUrl: './create-note.component.html',
  styleUrls: ['./create-note.component.css']
})
export class CreateNoteComponent extends AppComponentBase {
  preViewContent = ''; // 文章预览内容，转换层html后的
  @ViewChild('createNoteModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  term = new FormControl();
    active: boolean = false;
    saving: boolean = false;
    note: CreateNoteDto = null;
    notes: NoteDto[] = null;

    constructor(
        injector: Injector,
        private _noteService: NoteServiceProxy,
    ) {
        super(injector);
    }
    show(): void {
        this.active = true;
        this.modal.show();
        this.note = new CreateNoteDto();
        this.term.valueChanges  // 监测输入文本框的变化同步更新预览 400ms
                .debounceTime(400)
                .distinctUntilChanged()
                .subscribe(term => {
                   this.preViewContent = marked();
                });
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }

    save(): void {
        //TODO: Refactor this, don't use jQuery style code
      //var notes = [];
      //$(this.modalContent.nativeElement).find("[name=role]").each((ind: number, elem: Element) => {
        //if ($(elem).is(":checked") == true) {
          //roles.push(elem.getAttribute("value").valueOf());
        //}
      //});

        //this.note. = roles;
        this.saving = true;
        this._noteService.create(this.note)
            .finally(() => { this.saving = false; })
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
