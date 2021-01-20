// mc++ // Copyright (c) Microsoft Corporation.
// mc++ // All rights reserved.
// mc++ //
// mc++ // This code is licensed under the MIT License.
// mc++ //
// mc++ // Permission is hereby granted, free of charge, to any person obtaining a copy
// mc++ // of this software and associated documentation files(the "Software"), to deal
// mc++ // in the Software without restriction, including without limitation the rights
// mc++ // to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// mc++ // copies of the Software, and to permit persons to whom the Software is
// mc++ // furnished to do so, subject to the following conditions :
// mc++ //
// mc++ // The above copyright notice and this permission notice shall be included in
// mc++ // all copies or substantial portions of the Software.
// mc++ //
// mc++ // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// mc++ // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// mc++ // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// mc++ // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// mc++ // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// mc++ // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// mc++ // THE SOFTWARE.
// mc++ 
// mc++ package com.azuresamples.msalandroidapp;
// mc++ 
// mc++ import android.os.Bundle;
// mc++ 
// mc++ import androidx.annotation.NonNull;
// mc++ import androidx.appcompat.app.ActionBarDrawerToggle;
// mc++ import androidx.appcompat.app.AppCompatActivity;
// mc++ import androidx.appcompat.widget.Toolbar;
// mc++ import androidx.constraintlayout.widget.ConstraintLayout;
// mc++ import androidx.core.view.GravityCompat;
// mc++ 
// mc++ import android.view.MenuItem;
// mc++ import android.view.View;
// mc++ 
// mc++ import androidx.drawerlayout.widget.DrawerLayout;
// mc++ import androidx.fragment.app.Fragment;
// mc++ import androidx.fragment.app.FragmentTransaction;
// mc++ 
// mc++ 
// mc++ import com.google.android.material.navigation.NavigationView;
// mc++ 
// mc++ public class MainActivity extends AppCompatActivity
// mc++         implements NavigationView.OnNavigationItemSelectedListener,
// mc++         OnFragmentInteractionListener{
// mc++ 
// mc++     enum AppFragment {
// mc++         SingleAccount,
// mc++         MultipleAccount,
// mc++         B2C
// mc++     }
// mc++ 
// mc++     private AppFragment mCurrentFragment;
// mc++ 
// mc++     private ConstraintLayout mContentMain;
// mc++ 
// mc++     @Override
// mc++     protected void onCreate(Bundle savedInstanceState) {
// mc++         super.onCreate(savedInstanceState);
// mc++         setContentView(R.layout.activity_main);
// mc++ 
// mc++         mContentMain = findViewById(R.id.content_main);
// mc++ 
// mc++         Toolbar toolbar = findViewById(R.id.toolbar);
// mc++         setSupportActionBar(toolbar);
// mc++         DrawerLayout drawer = findViewById(R.id.drawer_layout);
// mc++         NavigationView navigationView = findViewById(R.id.nav_view);
// mc++         ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
// mc++                 this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
// mc++         drawer.addDrawerListener(toggle);
// mc++         toggle.syncState();
// mc++         navigationView.setNavigationItemSelectedListener(this);
// mc++ 
// mc++         //Set default fragment
// mc++         navigationView.setCheckedItem(R.id.nav_single_account);
// mc++         setCurrentFragment(AppFragment.SingleAccount);
// mc++     }
// mc++ 
// mc++     @Override
// mc++     public boolean onNavigationItemSelected(final MenuItem item) {
// mc++         final DrawerLayout drawer = findViewById(R.id.drawer_layout);
// mc++         drawer.addDrawerListener(new DrawerLayout.DrawerListener() {
// mc++             @Override
// mc++             public void onDrawerSlide(@NonNull View drawerView, float slideOffset) { }
// mc++ 
// mc++             @Override
// mc++             public void onDrawerOpened(@NonNull View drawerView) { }
// mc++ 
// mc++             @Override
// mc++             public void onDrawerClosed(@NonNull View drawerView) {
// mc++                 // Handle navigation view item clicks here.
// mc++                 int id = item.getItemId();
// mc++ 
// mc++                 if (id == R.id.nav_single_account) {
// mc++                     setCurrentFragment(AppFragment.SingleAccount);
// mc++                 }
// mc++ 
// mc++                 if (id == R.id.nav_multiple_account) {
// mc++                     setCurrentFragment(AppFragment.MultipleAccount);
// mc++                 }
// mc++ 
// mc++                 if (id == R.id.nav_b2c) {
// mc++                     setCurrentFragment(AppFragment.B2C);
// mc++                 }
// mc++ 
// mc++                 drawer.removeDrawerListener(this);
// mc++             }
// mc++ 
// mc++             @Override
// mc++             public void onDrawerStateChanged(int newState) { }
// mc++         });
// mc++ 
// mc++         drawer.closeDrawer(GravityCompat.START);
// mc++         return true;
// mc++     }
// mc++ 
// mc++     private void setCurrentFragment(final AppFragment newFragment){
// mc++         if (newFragment == mCurrentFragment) {
// mc++             return;
// mc++         }
// mc++ 
// mc++         mCurrentFragment = newFragment;
// mc++         setHeaderString(mCurrentFragment);
// mc++         displayFragment(mCurrentFragment);
// mc++     }
// mc++ 
// mc++     private void setHeaderString(final AppFragment fragment){
// mc++         switch (fragment) {
// mc++             case SingleAccount:
// mc++                 getSupportActionBar().setTitle("Single Account Mode");
// mc++                 return;
// mc++ 
// mc++             case MultipleAccount:
// mc++                 getSupportActionBar().setTitle("Multiple Account Mode");
// mc++                 return;
// mc++ 
// mc++             case B2C:
// mc++                 getSupportActionBar().setTitle("B2C Mode");
// mc++                 return;
// mc++         }
// mc++     }
// mc++ 
// mc++     private void displayFragment(final AppFragment fragment){
// mc++         switch (fragment) {
// mc++             case SingleAccount:
// mc++                 attachFragment(new SingleAccountModeFragment());
// mc++                 return;
// mc++ 
// mc++             case MultipleAccount:
// mc++                 attachFragment(new MultipleAccountModeFragment());
// mc++                 return;
// mc++ 
// mc++             case B2C:
// mc++                 attachFragment(new B2CModeFragment());
// mc++                 return;
// mc++         }
// mc++     }
// mc++ 
// mc++     private void attachFragment(final Fragment fragment) {
// mc++         getSupportFragmentManager()
// mc++                 .beginTransaction()
// mc++                 .setTransitionStyle(FragmentTransaction.TRANSIT_FRAGMENT_FADE)
// mc++                 .replace(mContentMain.getId(),fragment)
// mc++                 .commit();
// mc++     }
// mc++ }
