
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

     <v-toolbar color="black" dark fixed app>
       <div class="logo">
      <img class="logoImg" src="../assets/Geshdo-logo.png" @click="homeRedirect">
       </div>
          <v-spacer></v-spacer>
          <div v-if="isLoggedIn" class="hamburger">
     <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
     </div>
     <div class="login-navbar" v-if="!isLoggedIn">
            <button class="login btn" @click="login">Log in</button>
            <button class="register btn" @click="register">Register</button>
     </div>
 
     </v-toolbar>
  
</div>
  
</template>

<script>
export default {
  data(){
    return{
        isLoggedIn:false,
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

  login(){
    console.log('logging in');
  },

  register(){
    console.log('registering');
  }
 },

 created(){
   if (this.$store.state.currLoggedInUser.id === undefined){
     
   }
 }
}
</script>

<style scoped>



.logo {
  padding-left: 5vw;
  padding-top: 1vw;
}

.logoImg {
  width: 90%;
  margin-bottom: -1vh;
  user-select: none
}



.logoImg:hover{
  cursor: pointer;
}

.hamburger, .login-navbar {
  padding-right: 5vw;
  padding-top: 1vw;
}

.v-btn--icon.v-size--default .v-icon, .v-btn--fab.v-size--default .v-icon{
  font-size: 300%!important;
}

.v-list-item--dense, .v-list--dense .v-list-item{
  padding-top:3vh;
}

  
.v-application .black {
  background-color: #1e1e1e !important;
  height: 4.5vw!important;
}

.login-navbar{
  display: flex;
  flex-direction: row;
  gap:2vw;
}

.btn{
    background: -webkit-linear-gradient(rgb(153, 53, 219), rgb(226, 126, 196));
    font-size:1.4vw;

  -webkit-background-clip: text;
  background-clip:text;
  -webkit-text-fill-color: transparent;
}







</style>