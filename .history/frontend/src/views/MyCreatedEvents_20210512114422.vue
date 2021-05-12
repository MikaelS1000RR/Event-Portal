<template>
  <div class="myCreated-Events-container">


     <div class="event-list" v-model=filteredEvents">
      <EventItem v-for="event of events" :key="event.id" :event="event" />
    </div>

  </div>
</template>

<script>
import EventItem from "../components/EventItem.vue";

export default {

  data() {
    return {
      myEvents: [],

    }
  },
  components: {
    EventItem,
  },

  computed: {
     events(){
       return this.$store.state.events;
     },
   
    hostName() {
       const userName = auth.getAccount().name;
          this.$store.commit("setAccount", auth.getAccount());
          return userName;
    }
    
  },

  methods: {
    async filterEvents() {
      if(this.events === userName) {
        <h1>HIHOI</h1>
      }
    }
  }


}
</script>

<style scoped>

</style>