<template>
  <v-app class="app">
    <Navbar />
    <v-main>
      <Home />
    </v-main>
  </v-app>
</template>

<script>
import Home from "./views/Home.vue";
import Navbar from "./components/Navbar.vue";
export default {
  name: "App",

  components: {
    Home,
    Navbar,
  },

 created(){
  //this.$store.dispatch('fetchEvents')
 },
  data: () => ({
    //
  }),
};
</script>


<style>
@import url('https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100;0,400;0,600;0,700;0,800;1,100;1,600&display=swap');

*,
::before,
::after {
  padding: 0;
  margin: 0;
  font-family: "Montserrat", sans-serif;
 
  
  box-sizing: border-box;


}

body {
  margin: 0;

  
  overflow-x: hidden;
   
}

</style>