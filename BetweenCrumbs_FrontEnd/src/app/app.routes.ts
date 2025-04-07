import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { RecipesComponent } from './recipes/recipes.component';
import { WhoareweComponent } from './whoarewe/whoarewe.component';
import { ContactComponent } from './contact/contact.component';
import { RecipedetailsComponent } from './recipedetails/recipedetails.component';


export const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'recipes', component: RecipesComponent },
  { path: 'who-are-we', component: WhoareweComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'recipes/recipedetails/:idMeal', component: RecipedetailsComponent },
  { path: '', redirectTo: '/recipes', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
