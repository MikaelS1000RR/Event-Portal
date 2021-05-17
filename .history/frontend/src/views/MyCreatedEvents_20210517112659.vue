<template>
  <div class="container">
    <div class="gehsdo-logo">

      <div class="bob">
      <div class="searchbar">
        <input
        class="inp"
          type="text"
          placeholder="Search events..."
          v-model="searchQuery"
        />
      </div>
        <EventItem v-for="event of events" :key="event.id" :event="event" />
      </div>
    </div>
  </div>
</template>

<script>
import EventItem from "../components/EventItem.vue";

export default {
  data() {
    return {
      searchQuery: "",
    };
  },
  components: {
    EventItem,
  },

  computed: {
    events() {
      let myEvents = this.$store.state.allEvents.filter(
        (event) =>
          event.hostId === this.$store.state.account.homeAccountIdentifier
      );

      console.log(myEvents);

      if (this.searchQuery !== "") {
        myEvents = myEvents.filter((event) =>
          event.name.toLowerCase().includes(this.searchQuery.toLowerCase())
        );

        console.log(myEvents);
      }

      return myEvents;
    },
  },

  async created() {
    await this.$store.dispatch("fetchEvents");

    return { searchedEvents, seatch };
  },
};
</script>

<style scoped>


.container {
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
}

.gehsdo-logo {
  height: 50%;
  width: 70%;
  display: flex;
  align-items: center;
  justify-content: center;
  margin-left: 10vw;

  background-size: 90%;
}

.bob {
  margin-right: 20vh;
}

.inp {
  color:white;
}


/*background-image: url("../assets/GeshdoT.png"); */
</style>