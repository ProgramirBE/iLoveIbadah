import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  currentSection: string = 'publicProfile'; // Default section
  profile = {
    fullName: '',
    email: '',
    profilePicture: '',
    bio: '',
    url: '',
    favoriteDua: '',
    location: '',
  };
  newUsername: string = ''; // Gebruikersnaam wijzigen
  currentPassword: string = ''; // Huidig wachtwoord
  newPassword: string = ''; // Nieuw wachtwoord

  constructor() {}

  ngOnInit(): void {
    // Laad profielgegevens (vervang dit door echte API-aanroepen indien nodig)
    this.loadProfile();
  }

  loadProfile(): void {
    // Mock data voor demonstratie
    this.profile = {
      fullName: 'John Doe',
      email: 'johndoe@example.com',
      profilePicture: '',
      bio: 'I am a dedicated learner and enthusiast.',
      url: 'https://example.com',
      favoriteDua: 'Rabbi zidni ilma',
      location: 'New York, USA',
    };
  }

  navigateToSection(section: string): void {
    this.currentSection = section;
  }

  updateProfile(): void {
    console.log('Profile updated:', this.profile);
    // Voeg hier API-aanroep toe om profielgegevens op te slaan
  }

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

  onUsernameChange(): void {
    console.log('Username updated to:', this.newUsername);
    // Voeg hier API-aanroep toe om de gebruikersnaam bij te werken
  }

  onPasswordChange(): void {
    console.log('Password updated:', {
      currentPassword: this.currentPassword,
      newPassword: this.newPassword,
    });
    // Voeg hier API-aanroep toe om het wachtwoord bij te werken
  }

  onLocationChange(): void {
    console.log('Location updated:', this.profile.location);
    // Voeg hier API-aanroep toe om de locatie op te slaan
  }
}
