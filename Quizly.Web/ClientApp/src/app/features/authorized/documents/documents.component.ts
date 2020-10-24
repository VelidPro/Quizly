import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-documents',
  templateUrl: './documents.component.html',
  styleUrls: ['./documents.component.scss']
})
export class DocumentsComponent implements OnInit {

  activePanel: string = 'recent';
  constructor() { }

  ngOnInit() {
  }
  setActivePanel(activePanel: string){
    this.activePanel = activePanel;
  }
}
