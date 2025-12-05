import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { LayoutComponent, NavbarComponent } from "./components";
import { RouterModule } from "@angular/router";

@NgModule({
    declarations:[
        LayoutComponent,
        NavbarComponent
    ],
    imports:[
        FormsModule,
        CommonModule,
        RouterModule
    ],
    exports:[
        FormsModule,
        CommonModule,
        LayoutComponent,
        RouterModule,
        NavbarComponent
    ],
    providers:[]
})

export class SharedModule{

}