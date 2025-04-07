import { Component, inject } from '@angular/core';
import { RecipeService } from '../recipe.service';
import { mealDetailsView } from '../../../recipes.models';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { MatGridListModule } from '@angular/material/grid-list';
import { NgFor, NgIf } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-recipedetails',
  standalone: true,
  imports: [MatGridListModule, NgIf, NgFor, RouterLink, MatButtonModule],
  templateUrl: './recipedetails.component.html',
  styleUrl: './recipedetails.component.css'
})
export class RecipedetailsComponent {
  idReceta: string;
  route1!: ActivatedRoute;
  useValue!: {
    snapshot: {
      url: [{ path: 1; }, { path: 2; }, { path: 3; }];
    };
  };
  recipeService = inject(RecipeService);
  mealDetailsView?: mealDetailsView;
recipes: any;

  constructor(private route: ActivatedRoute){
    console.log(this.route,this.useValue);
    this.idReceta = this.route.snapshot.paramMap.get('idMeal')!;
    console.log(this.idReceta);
    this.recipeService.obtenerDetallesReceta(this.idReceta).subscribe(mealDetailsView => {
      this.mealDetailsView = mealDetailsView;
    })
  }
}
