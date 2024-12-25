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

  // Variables for Account Section
  newUsername: string = '';
  currentPassword: string = '';
  newPassword: string = '';

  constructor() {}

  ngOnInit(): void {
    // Load profile data (this can be replaced with actual API calls)
    this.loadProfile();
  }

  loadProfile(): void {
    // Mock data for demonstration purposes
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
    // Logic to update the profile (e.g., API call)
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
    // Logic to update the username (e.g., API call)
    this.newUsername = ''; // Clear the input after saving
  }

  onPasswordChange(): void {
    console.log('Password change requested:', {
      currentPassword: this.currentPassword,
      newPassword: this.newPassword,
    });
    // Logic to update the password (e.g., API call with validation)
    this.currentPassword = ''; // Clear current password input
    this.newPassword = ''; // Clear new password input
  }
}
