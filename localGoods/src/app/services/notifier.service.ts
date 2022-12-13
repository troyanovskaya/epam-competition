import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NotifierComponent } from '../components/notifier/notifier.component';

@Injectable({
  providedIn: 'root'
})
export class NotifierService {
  constructor(private snackBar: MatSnackBar) { }

  showNotification(message: string, messageType: 'ERROR' | 'SUCCESS'){
    this.snackBar.openFromComponent(NotifierComponent,{
      data: {
        message: message,
        type: messageType
      },
      duration: 3000,
      horizontalPosition: 'center',
      verticalPosition: 'top',
      panelClass: messageType
    });
  }
}
