<template>
  <v-app class="app">
    <Navbar />
    <v-main>
     
      <router-view></router-view>
  
    </v-main>
   <Footer/>
  </v-app>
</template>

<script>

import Navbar from "./components/Navbar.vue";
import Footer from "./components/Footer.vue"
import "../index.css";

export default {
  name: "App",

  components: {
   
    Navbar,
    Footer
  },

 created(){
  //this.$store.dispatch('fetchEvents')
 },
  data: () => ({
    //
  }),
};
</script>

<style scoped>

</style>
