
<template>


<div class="navbar-wrapper">

     <v-toolbar color="black" dark fixed app>
       <div class="logo">
         
      <img class="logoImg" src="../assets/GeshdoT.png" @click="homeRedirect">
       </div>
          <v-spacer></v-spacer>
          <div v-if="isLoggedIn" class="hamburger">
     <v-app-bar-nav-icon></v-app-bar-nav-icon>
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
        isLoggedIn:false
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





.logoImg {
  width: 15%;
  margin-bottom: -1vh;
  margin-left: 1vh;
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