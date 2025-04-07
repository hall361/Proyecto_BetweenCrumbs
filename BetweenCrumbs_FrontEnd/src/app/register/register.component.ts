import { NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [NgIf],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {

  registerForm!: FormGroup;

  constructor(private fb: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      idUsuario: ['', Validators.required],
      nombreUsuario: ['', Validators.required],
      correoElectronico: ['', [Validators.required, Validators.email]],
      contrasena: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  // Método que se ejecuta al enviar el formulario
  onSubmit(): void {
    if (this.registerForm.valid) {
      const usuarioData = this.registerForm.value;

      console.log('Usuario creado: ', usuarioData);

      // Aquí podrías hacer la llamada a un servicio para guardar el usuario
      // Por ahora, simulamos que el usuario fue guardado y redirigimos a la página de verificación
      this.router.navigate(['/verify']);
    }
  }
}
