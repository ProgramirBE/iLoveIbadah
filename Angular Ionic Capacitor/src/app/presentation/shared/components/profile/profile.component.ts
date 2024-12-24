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
    // Here, you can call an API to save the updated profile data
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
}
