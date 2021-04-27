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
import "../index.css";

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

<style scoped>

</style>
