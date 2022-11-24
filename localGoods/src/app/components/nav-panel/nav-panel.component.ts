import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-panel',
  templateUrl: './nav-panel.component.html',
  styleUrls: ['./nav-panel.component.css']
})
export class NavPanelComponent implements OnInit {
  arrOfOptions: {name:string, categories:string[]}[] = [
    {name: 'farm boxes', categories: ['sesonal produce boxes',
  'cooks`s boxes']},
  {name: 'produce', categories: ['peak season',
  'fruit', 'vegetables', 'herbs & aromatics', 'frozen']},
  {name: 'meat & seafood', categories: ['seafood',
  'poultry', 'beef', 'pork', 'deli meat & charcuterie', 'lamb']},
  {name: 'dairy & eggs', categories: ['milk and cream',
  'eggs & butter', 'cheese', 'yogurt & cultured dairy', 'plant based']},
  {name: 'bakery', categories: ['bread',
  'buns & rolls', 'bagels and breakfast', 'desserts', 'tortillas & dought', 'gluten free' ]},
  {name: 'pantry', categories: ['pasta & noodles',
  'grains & beans', 'snacks', 'oil, vinegar & spices',
   'baking ingredients', 'sauces', 'honey & syrup', 'jams & nut butter']},
  {name: 'drinks', categories: ['coffee',
  'juice & kombucha', 'tea & elixirs', 'sparkling']},
  {name: 'easy meals', categories: ['bundles & kits',
  'frozen meals & pizza', 'soups & broths']},
  {name: 'new & seasonal', categories: ['new',
  'on sale', 'best sellers']},

  ]

  constructor() { }

  ngOnInit(): void {
  }

}
