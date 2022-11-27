import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-meny-left-panel',
  templateUrl: './meny-left-panel.component.html',
  styleUrls: ['./meny-left-panel.component.css']
})
export class MenyLeftPanelComponent implements OnInit {
  arrOfOptions: string[] = [ 'farm boxes', 'produce','meat & seafood',
  'dairy & eggs','bakery','pantry','drinks','easy meals', 'new & seasonal']

  constructor() { }

  ngOnInit(): void {
  }

}
