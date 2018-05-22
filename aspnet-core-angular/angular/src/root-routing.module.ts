import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {NoteComponent} from '@app/blog/note/note.component';
import {NoteBookComponent} from '@app/blog/note-book/note-book.component';

const routes: Routes = [
    { path: '', redirectTo: '/app/home', pathMatch: 'full' },
    {
        path: 'account',
        loadChildren: 'account/account.module#AccountModule', //Lazy load account module
        data: { preload: true }
    },
    {
        path: 'app',
        loadChildren: 'app/app.module#AppModule', //Lazy load account module
        data: { preload: true }
    }
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
    providers: []
})
export class RootRoutingModule { }