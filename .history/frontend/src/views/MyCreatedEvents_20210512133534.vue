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
      showMyevents: "",
    }
  },
  components: {
    EventItem,
  },

  computed: {
     events(){
       return this.$store.state.events;
     },
    
  },

  methods: {
    async filterEvents() {
       
    }
  },
 


}
</script>

<style scoped>

</style>