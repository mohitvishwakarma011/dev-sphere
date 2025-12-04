import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { LayoutComponent } from "./components";

@NgModule({
    declarations:[
        LayoutComponent
    ],
    imports:[
        FormsModule,
        CommonModule,
    ],
    exports:[
        FormsModule,
        CommonModule,
        LayoutComponent
    ],
    providers:[]
})

export class SharedModule{

}