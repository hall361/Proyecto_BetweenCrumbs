import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {mealDetailsView, mealView} from '../../recipes.models';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  constructor() { }

  private http = inject(HttpClient);
  private URLRecipeQuery = 'https://www.themealdb.com/api/json/v1/1/filter.php?c=Seafood'
  private URLRecipeDetails = 'https://www.themealdb.com/api/json/v1/1/lookup.php?i='

  public obtenerTodos(): Observable<mealView>{
    return this.http.get<mealView>(this.URLRecipeQuery);
  }

  public obtenerDetallesReceta(idReceta: string): Observable<mealDetailsView>{
    return this.http.get<mealDetailsView>(this.URLRecipeDetails + idReceta);
  }
}
