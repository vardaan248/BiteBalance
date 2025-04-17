import { Component, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'Bite Balance';
  isDarkMode = false;

  constructor(private renderer: Renderer2) {}

  toggleTheme(): void {
    this.isDarkMode = !this.isDarkMode;
    const themeClass = this.isDarkMode ? 'dark-theme' : 'light-theme';

    // Remove both classes, then add the selected one
    this.renderer.removeClass(document.body, 'dark-theme');
    this.renderer.removeClass(document.body, 'light-theme');
    this.renderer.addClass(document.body, themeClass);
  }

  get themeIcon(): string {
    return this.isDarkMode ? 'assets/sun.png' : 'assets/moon.png';
  }
}
