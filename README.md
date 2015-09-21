# XamarinFormsAutofacMvvmStarterKit
A basic starter kit for building MVVM Xamarin Forms applications with Autofac.

## Credits
I want to thank Jonathan Yeats over at http://adventuresinxamarinforms.com for the base of this starter pack and for his permission to tweak it and publish it here.

## Features at a glance
- View Model navigation.
- Convention over configuration automatic registration of views and view models.
- Hooks View Model into Pushed, Popped, OnAppearing, and OnDisappearing events.
- Automatic View Model disposal if it implments IDisposable when the view is popped off the navigation stack.
- Interface to expose Xamarin.Forms.Device static class for testing purposes.
