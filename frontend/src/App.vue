<template>
  <v-app>
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

  background-image: radial-gradient(at top left, black, transparent),
    radial-gradient(at top right, rgb(70, 0, 128), transparent),
    radial-gradient(at bottom left, #6133ed68, transparent);
}

body {
  margin: 0;
  font-family: "Montserrat", sans-serif;
  overflow-x: hidden;
}
</style>