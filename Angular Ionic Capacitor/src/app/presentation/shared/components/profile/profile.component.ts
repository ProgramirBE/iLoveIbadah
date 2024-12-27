import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  currentSection: string = 'publicProfile'; // Default section
  isEditing: boolean = false; // Controle voor bewerkmodus
  profile = {
    fullName: '',
    email: '',
    profilePicture: '',
    bio: '',
    url: '',
    favoriteDua: '',
    location: '',
  };
  account = {
    username: '',
    currentPassword: '',
    newPassword: '',
  };

  constructor() {}

  ngOnInit(): void {
    this.loadProfile();
    this.loadAccountSettings();
  }

  // Mockdata laden voor profiel
  loadProfile(): void {
    this.profile = {
      fullName: 'John Doe',
      email: 'johndoe@example.com',
      profilePicture: 'https://via.placeholder.com/150',
      bio: 'Dedicated learner and enthusiast.',
      url: 'https://example.com',
      favoriteDua: 'Rabbi zidni ilma',
      location: 'New York, USA',
    };
  }

  // Mockdata laden voor accountinstellingen
  loadAccountSettings(): void {
    this.account = {
      username: 'john_doe',
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
  updateProfile(): void {
    console.log('Profiel bijgewerkt:', this.profile);
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
  saveUsername(): void {
    if (this.account.username.trim() !== '') {
      console.log('Gebruikersnaam bijgewerkt naar:', this.account.username);
      alert('Username updated successfully!');
    } else {
      alert('Username cannot be empty!');
    }
  }

  // Wachtwoord bijwerken
  savePassword(): void {
    if (this.account.currentPassword && this.account.newPassword) {
      console.log(
        'Wachtwoord bijgewerkt. Huidig wachtwoord:',
        this.account.currentPassword,
        'Nieuw wachtwoord:',
        this.account.newPassword
      );
      alert('Password updated successfully!');
    } else {
      alert('Please fill in both current and new passwords!');
    }
  }

  // Locatie bijwerken
  saveLocation(): void {
    if (this.profile.location.trim() !== '') {
      console.log('Locatie bijgewerkt naar:', this.profile.location);
      alert('Location updated successfully!');
    } else {
      alert('Location cannot be empty!');
    }
  }

  // Profielfoto uploaden
  uploadProfilePicture(event: any): void {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        this.profile.profilePicture = reader.result as string;
      };
      reader.readAsDataURL(file);
    }
  }
}
