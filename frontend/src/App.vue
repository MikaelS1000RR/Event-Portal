<template>
  <v-app class="app">

    <Navbar />
    <v-main>
     <div class="routerView">
      <router-view></router-view>
    </div>
    </v-main>
 
  </v-app>
</template>

<script>
import Home from "./views/Home.vue";
import Navbar from "./components/Navbar.vue";
import CreateEvent from "./views/CreateEvent.vue";
import "../index.css";

export default {
  name: "App",

  components: {
    Home,
    Navbar,
    CreateEvent
  },

  data: () => ({
    //
  }),
};
</script>

<style scoped>

</style>
