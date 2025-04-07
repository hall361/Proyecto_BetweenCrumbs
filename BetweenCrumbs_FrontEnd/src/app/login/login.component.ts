import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  loginForm!: FormGroup;

  constructor(private fb: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      correoElectronico: ['', [Validators.required, Validators.email]],
      contrasena: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  // Método que se ejecuta al enviar el formulario
  onSubmit(): void {
    if (this.loginForm.valid) {
      const usuarioData = this.loginForm.value;

      console.log('Usuario creado: ', usuarioData);

      // Aquí podrías hacer la llamada a un servicio para guardar el usuario
      // Por ahora, simulamos que el usuario fue guardado y redirigimos a la página de verificación
      this.router.navigate(['/verify']);
    }
  }
}

