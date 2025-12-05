import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { LayoutComponent, NavbarComponent, PostCardComponent } from "./components";
import { RouterModule } from "@angular/router";
import { HttpClientModule } from "@angular/common/http";

@NgModule({
    declarations: [
        LayoutComponent,
        NavbarComponent,
        PostCardComponent
    ],
    imports: [
        FormsModule,
        CommonModule,
        RouterModule,
        HttpClientModule
    ],
    exports: [
        FormsModule,
        CommonModule,
        LayoutComponent,
        RouterModule,
        NavbarComponent,
        PostCardComponent,
        HttpClientModule
    ],
    providers: [

    ]
})

export class SharedModule {

}