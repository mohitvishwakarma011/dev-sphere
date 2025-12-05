import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent, LoginComponent, PostsComponent, ProfileComponent } from './components';
import { JwtIntercepter } from './helpers';
import { SharedModule } from './shared/shared.module';
import { PostService } from './services';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    PostsComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    SharedModule,

],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtIntercepter,
      multi: true
    },
    PostService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
