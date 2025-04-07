import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-verify',
  standalone: true,
  imports: [NgIf, NgFor],
  templateUrl: './verify.component.html',
  styleUrl: './verify.component.css'
})
export class VerifyComponent implements OnInit {

  verifyForm!: FormGroup;
  captchaDigits: number[] = [];
  captchaSum: number = 0;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.generateCaptcha();

    this.verifyForm = this.fb.group({
      verificationCode: ['', [Validators.required, Validators.pattern("^[0-9]+$")]]
    });
  }

  // Genera los 6 dígitos aleatorios y calcula su suma
  generateCaptcha(): void {
    this.captchaDigits = [];
    this.captchaSum = 0;

    for (let i = 0; i < 6; i++) {
      const digit = Math.floor(Math.random() * 10); // Genera un dígito entre 0 y 9
      this.captchaDigits.push(digit);
      this.captchaSum += digit;
    }
  }

  // Valida si la suma ingresada es correcta
  onSubmit(): void {
    const userAnswer = parseInt(this.verifyForm.value.verificationCode, 10);
    
    if (userAnswer === this.captchaSum) {
      console.log('Verificación exitosa!');
      // Aquí podrías redirigir al usuario o hacer alguna acción extra.
    } else {
      console.error('Error: La suma ingresada es incorrecta.');
      this.verifyForm.controls['verificationCode'].setErrors({ incorrect: true });
    }
  }
}
