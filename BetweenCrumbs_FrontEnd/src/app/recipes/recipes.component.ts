import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule, MatGridTile} from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { RecipeService } from '../recipe.service';
import { mealView } from '../../../recipes.models';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-recipes',
  standalone: true,
  imports: [MatGridListModule, RouterLink, MatButtonModule, MatIconModule,MatGridTile, NgFor],
  templateUrl: './recipes.component.html',
  styleUrl: './recipes.component.css'
})
export class RecipesComponent {
  recipeService = inject(RecipeService);
  mealView?: mealView;

  constructor(){
    this.recipeService.obtenerTodos().subscribe(mealView => {
      this.mealView = mealView;
    })
  }
}
