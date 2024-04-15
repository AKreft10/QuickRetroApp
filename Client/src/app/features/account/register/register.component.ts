import { Component, EventEmitter, Output, output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterUser } from './register.interface';
import { RegisterService } from './register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  @Output() dataEmmiter = new EventEmitter<boolean>(false);
  registerForm: FormGroup;

  constructor(private fb: FormBuilder, private registerService : RegisterService) {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      nickname: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      confirmPassword: ['', [Validators.required]]
    }, {
      validator: this.mustMatch('password', 'confirmPassword')
    });
  }

  mustMatch(password: string, confirmPassword: string) {
    return (formGroup: FormGroup) => {
      const passwordControl = formGroup.controls[password];
      const confirmPasswordControl = formGroup.controls[confirmPassword];

      if (confirmPasswordControl.errors && !confirmPasswordControl.errors['mustMatch']) {
        return;
      }

      // set error on confirmPasswordControl if validation fails
      if (passwordControl.value !== confirmPasswordControl.value) {
        confirmPasswordControl.setErrors({ mustMatch: true });
      } else {
        confirmPasswordControl.setErrors(null);
      }
    }
  }

  onSubmit() {
    if (this.registerForm.valid) {

      var formValues = this.registerForm.value;

      var registerUserData : RegisterUser = 
      {
        email: formValues['email'],
        nickname: formValues['nickname'],
        passwordHash: formValues['password'],
        nationality: 'Polish'
      };

      this.registerService.sendRegisterForm(registerUserData)
      .subscribe(result => {
        console.log(result);
      })
    }
  }

  switchForms() {
    console.log('switch')
    this.dataEmmiter.emit(true);
  }
}