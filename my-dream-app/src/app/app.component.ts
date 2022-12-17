import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'my-dream-app';
  matakuliah = 'Pemrograman Framework';
  changematakuliah() {
    this.matakuliah = 'Pemrograman Visual';
  }
}
