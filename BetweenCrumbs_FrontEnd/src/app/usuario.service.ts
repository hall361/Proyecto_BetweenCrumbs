import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { usuarioResponse, usuarioRequest } from '../../usuario.models';
import { response } from 'express';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  
  constructor() { }

  private http = inject(HttpClient);
  private URLRecipeQuery = 'https://www.themealdb.com/api/json/v1/1/filter.php?c=Seafood'
  private URLRecipeDetails = 'https://www.themealdb.com/api/json/v1/1/lookup.php?i='
  private URLCrearUsuario = 'https://localhost:7046/api/Usuario/CrearUsuario'

  public crearUsuario(usuario: usuarioRequest){

    // this.http.post(this.URLCrearUsuario).map((usuario) => {return usuario}));

  }

  // public loginUsuario(nombreUsuario: string, password: string): Observable<usuarioResponse>{
  //   this.http.get<usuarioResponse>(this.URLRecipeDetails + nombreUsuario + password);
  // }
}
