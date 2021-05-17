<template>
  <div class="container">
      <div class="searchbar">
        <input
        class="inp"
          type="text"
          placeholder="Search events... 🔍"
          v-model="searchQuery"
        />

      <div class="event-list">
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
  flex-direction: column;
}



input[type=text] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  box-sizing: border-box;
  border: 3px solid #ccc;
  border-radius: 5%;
  -webkit-transition: 0.4s;
  transition: 0.4s;
  outline: none;
  color: whitesmoke;
}

input[type=text]:focus {
  border: 3px solid rgb(98, 65, 177);
}


/*background-image: url("../assets/GeshdoT.png"); */
</style>