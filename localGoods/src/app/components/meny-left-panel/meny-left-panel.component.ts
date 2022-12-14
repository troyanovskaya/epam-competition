import { Component, OnInit } from '@angular/core';
import { CategoriesService } from 'src/app/services/categories.service';

@Component({
  selector: 'app-meny-left-panel',
  templateUrl: './meny-left-panel.component.html',
  styleUrls: ['./meny-left-panel.component.css']
})
export class MenyLeftPanelComponent implements OnInit {

  constructor(public categoriesService: CategoriesService) { }

  ngOnInit(): void {
  }

}
