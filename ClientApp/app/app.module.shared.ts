import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { TitleListComponent } from './components/title/title.component';
//import { TitleEditComponent } from './components/title/titleEdit.component';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        TitleListComponent,
        //TitleEditComponent
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'books', component: TitleListComponent },
            { path: 'tags', component: TitleListComponent },
            { path: 'issues', component: TitleListComponent },
            { path: 'titles', component: TitleListComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
};
