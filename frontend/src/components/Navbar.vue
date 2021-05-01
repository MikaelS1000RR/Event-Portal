
<template>


<div class="navbar-wrapper">

     <v-toolbar color="black" dark fixed app>
       <div class="logo">
      <img class="logoImg" src="../assets/Geshdo-logo.png" @click="homeRedirect">
       </div>
          <v-spacer></v-spacer>
          <div class="hamburger">
     <v-app-bar-nav-icon></v-app-bar-nav-icon>
     </div>
 
     </v-toolbar>
  
</div>
  
</template>

<script>
export default {
 methods:{
  homeRedirect(){
    this.$router.push("/");
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

.hamburger {
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







</style>