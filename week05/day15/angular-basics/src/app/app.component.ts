import { Component } from '@angular/core';
import { TableComponent } from './table/table.component';
import { ListComponent } from './list/list.component';
import { NestedListComponent } from './nested-list/nested-list.component';
import { LinkComponent } from './link/link.component';
import { AlertComponent } from './alert/alert.component';
import { LeapYearComponent } from './leap-year/leap-year.component';

@Component({
  selector: 'app-root',
  imports: [TableComponent,LinkComponent,ListComponent,NestedListComponent,AlertComponent,LeapYearComponent],
  templateUrl: './app.component.html' ,
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'angular-basics';
}
