import { Component, Injector, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { NoteServiceProxy, NoteDto, PagedResultDtoOfNoteDto, CreateNoteDto } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from "shared/paged-listing-component-base";
import { CreateNoteComponent } from "@app/blog/note/create-note/create-note.component";
import { EditNoteComponent } from "@app/blog/note/edit-note/edit-note.component";


@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.css'],
  animations: [appModuleAnimation()]
})
export class NoteComponent extends PagedListingComponentBase<NoteDto> {

  @ViewChild('createNoteModal') createNoteModdal: CreateNoteComponent;
  @ViewChild('editNoteModal') editNoteModal: EditNoteComponent;
  active: boolean = false;
  notes: NoteDto[] = [];

  constructor(
      injector: Injector,
      private _noteService: NoteServiceProxy
  ) {
      super(injector);
  }

  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
      this._noteService.getAll(request.skipCount, request.maxResultCount)
          .finally(() => {
              finishedCallback();
          })
          .subscribe((result: PagedResultDtoOfNoteDto) => {
              this.notes = result.items;
              this.showPaging(result, pageNumber);
          });
  }

    protected delete(note: NoteDto): void {
        abp.message.confirm(
            "Delete title '" + note.title + "'?",
            (result: boolean) => {
                if (result) {
                    this._noteService.delete(note.id)
                        .subscribe(() => {
                            abp.notify.info("Deleted title: " + note.title);
                            this.refresh();
                        });
                }
            }
        );
    }

    // Show Modals
    createNote(): void {
      this.createNoteModdal.show();
  }

  editNote(note: NoteDto): void {
      this.editNoteModal.show(note.id);
  }
}
