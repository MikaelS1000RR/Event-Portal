<template>
  <div class="myCreated-Events-container">

     <div class="event-list" >
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
      currEvent() {
      return this.$store.state.specEvent;
    },

    ifHost() {
      if(this.currEvent.)
    }
    
  },

  methods: {
    async filterEvents() {
       
    }
  },
 


}
</script>

<style scoped>

</style>