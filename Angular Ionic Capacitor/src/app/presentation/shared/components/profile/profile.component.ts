import { Component, OnInit } from '@angular/core';
import { UserAccount } from 'src/app/domain/models/user-account';
import { UserAccountsService } from 'src/app/infrastructure/services/proxies/internal/useraccounts.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  currentSection: string = 'userAccount'; // Default section
  isEditing: boolean = false; // Controle voor bewerkmodus
  userAccount: Partial<UserAccount> = {
    uniqueId: '',
    fullName: '',
    email: '',
    profilePictureTypeId: 0,
    emailConfirmed: false,
    currentLocation: 'Belgique',
    totalWarnings: 0,
    isPermanentlyBanned: false,

    //bio: '',
    //url: '',
    //favoriteDua: '',
    //: '',
  };
  account = {
    username: '',
    currentPassword: '',
    newPassword: '',
  };

  constructor(private userAccountService: UserAccountsService) {}

  ngOnInit(): void {
    this.loadUserAccount();
    this.loadAccountSettings();
  }

  // Mockdata laden voor profiel
  loadUserAccount(): void {
    const userId = localStorage.getItem('userId');
    if (userId) {
      this.userAccountService.getById().subscribe(
        (user: UserAccount) => {
          this.userAccount = user;
        },
        (error) => {
          console.error('Failed to load user information', error);
        }
      );
    }
  }

  // Mockdata laden voor accountinstellingen
  loadAccountSettings(): void {
    this.account = {
      username: '',
      currentPassword: '',
      newPassword: '',
    };
  }

  // Navigeren tussen secties
  navigateToSection(section: string): void {
    this.currentSection = section;
    this.isEditing = false; // Uitschakelen bewerkmodus bij sectiewissel
  }

  // Bewerkmodus activeren
  enableEdit(): void {
    this.isEditing = true;
  }

  // Bewerkmodus deactiveren
  disableEdit(): void {
    this.isEditing = false;
  }

  // Profiel bijwerken (mock)
  updateUserAccount(): void {
    console.log('Profiel bijgewerkt:', this.userAccount);
    alert('Profile updated successfully!');
    this.disableEdit();
  }

  // Accountinstellingen bijwerken (mock)
  updateAccountSettings(): void {
    console.log('Account instellingen bijgewerkt:', this.account);
    alert('Account settings updated successfully!');
    this.disableEdit();
  }

  // Username bijwerken
  updateFullName(): void {
    if (this.userAccount.fullName?.trim() !== '') {
      console.log('Gebruikersnaam bijgewerkt naar:', this.userAccount.fullName);
      alert('Username updated successfully!');
    } else {
      alert('Username cannot be empty!');
    }
  }

  // Wachtwoord bijwerken
  updatePasswordHash(): void {
    // if (this.userAccount. && this.account.newPassword) {
    //   console.log(
    //     'Wachtwoord bijgewerkt. Huidig wachtwoord:',
    //     this.account.currentPassword,
    //     'Nieuw wachtwoord:',
    //     this.account.newPassword
    //   );
    //   alert('Password updated successfully!');
    // } else {
    //   alert('Please fill in both current and new passwords!');
    // }
  }

  // Locatie bijwerken
  updateCurrentLocation(): void {
    const currentLocation = this.userAccount.currentLocation?.trim() ?? '';
    if (currentLocation !== '') {
      console.log('Locatie bijgewerkt naar:', currentLocation);
      alert('Location updated successfully!');
    } else {
      alert('Location cannot be empty!');
    }
  }

  // Profielfoto uploaden
  updateProfilePictureTypeId(event: any): void {
    // const file = event.target.files[0];
    // if (file) {
    //   const reader = new FileReader();
    //   reader.onload = () => {
    //     this.userAccount.profilePictureTypeId = reader.result as string;
    //   };
    //   reader.readAsDataURL(file);
    // }
  }
}
