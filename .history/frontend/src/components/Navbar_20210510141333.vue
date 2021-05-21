
<template>


<div class="navbar-wrapper">

   <v-navigation-drawer
      v-model="drawer"
      absolute
      temporary
      dark
    >
     

      <v-divider></v-divider>

      <v-list dense>
        <v-list-item  
         link
        >
          <v-list-item-icon>
            <v-icon>mdi-view-dashboard</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>My events</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item  
         link
        >
          <v-list-item-icon>
            <v-icon>mdi-calendar-star</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>Joined events</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
           <v-list-item  
         link
            @click="$router.push('/create-event')"
        >
          <v-list-item-icon>
            <v-icon>mdi-plus</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>Add event</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item  
         link 
      

        >
          <v-list-item-icon>
            <v-icon>mdi-logout</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>Log out</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

     <v-toolbar color="black" dark fixed app >
       <div class="logo hide">
      <img class="logoImg" src="../assets/Geshdo-logo.png" @click="homeRedirect">
       </div>
          <v-spacer></v-spacer>
          <div v-show="loggedIn" class="hamburger">
     <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
     </div>
     <div class="login-navbar" v-show="!loggedIn">
            <button class="login btn" @click="login">Log in</button>
            <button class="register btn" @click="register">Register</button>
     </div>
 
     </v-toolbar>
  
</div>
  
</template>

<script>

import { auth } from '/config/auth.js'

export default {
  data(){
    return{
       // isLoggedIn:false,
        drawer:null,
        items: [
          { title: 'Home', icon: 'mdi-view-dashboard' },
          { title: 'About', icon: 'mdi-forum' },
        ],
        
    }
  },
  
 methods:{
  homeRedirect(){
    this.$router.push("/");
  },

  async login(){
    auth.loginRedirect();

  },


  register(){
    auth.getAccount();
    console.log('registering',  auth.getAccount());
  },

  async logout(){
    this.$store.dispacth("logout")
  }
 },
  computed:{
    loggedIn:{
      get(){
         return this.$store.state.currLoggedInUser.id !== undefined ? true: false
      }
     
    }
  }
}
</script>

<style scoped>



.logoImg {
  width:150px;
  user-select: none
}

.logo{
   margin-left: 5vw;
  margin-bottom: -1vw;
  display: flex;
  align-items: center;
  justify-content: center;
}



.logoImg:hover{
  cursor: pointer;
}

.hamburger, .login-navbar {
  margin-right: 5vw;
  margin-top: 1vw;
}

.v-btn--icon.v-size--default .v-icon, .v-btn--fab.v-size--default .v-icon{
  font-size: 300%!important;
}

.v-list-item--dense, .v-list--dense .v-list-item{
  padding-top:3vh;
}

  
.v-application .black {
  background-color: #1e1e1e !important;
  height: 75px!important;
}

.login-navbar{
  display: flex;
  flex-direction: row;
  gap:20px;
  align-items: center;
  justify-content: center;
}

.btn{
    background: -webkit-linear-gradient(rgb(153, 53, 219), rgb(226, 126, 196));
    font-size:28px;

  -webkit-background-clip: text;
  background-clip:text;
  -webkit-text-fill-color: transparent;
}





@media only screen and (max-width: 1000px) {
 .btn{
   font-size:20px;
 }

}

@media only screen and (max-width: 750px) {
  
 .v-application .black{
   height:50px  !important;
 }

 .btn{
   font-size:15px;
 }
 .logo{
   margin:0px;
 }
 .logoImg {
   width:80px;
 }
}








</style>