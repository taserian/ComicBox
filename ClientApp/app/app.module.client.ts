import { NgModule, InjectionToken } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { TitleListComponent } from './components/title/title.component';
import { TitleEditComponent } from './components/title/title-edit.component';

import { TitleService } from './services/title.service';

import { sharedConfig } from './app.module.shared';

export let BASE_URL = new InjectionToken<string>("BASE_URL");

@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        TitleListComponent,
        TitleEditComponent
    ],
    imports: [
        BrowserModule,
        //FormsModule,
        HttpModule,
        BrowserAnimationsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'books', component: TitleListComponent },
            { path: 'tags', component: TitleListComponent },
            { path: 'issues', component: TitleListComponent },
            { path: 'titles', component: TitleListComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        TitleService,
        { provide: 'ORIGIN_URL', useValue: location.origin }
    ]
})
export class AppModule {
}


