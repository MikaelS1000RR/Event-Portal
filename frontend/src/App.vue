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

  data: () => ({
    //
  }),
};
</script>


<style>
@import url("https://fonts.googleapis.com/css2?family=Montserrat:wght@100&display=swap");

*,
::before,
::after {
  padding: 0;
  margin: 0;
   


}

body {
  margin: 0;
  font-family: "Montserrat", sans-serif;
  overflow-x: hidden;
   
}

</style>