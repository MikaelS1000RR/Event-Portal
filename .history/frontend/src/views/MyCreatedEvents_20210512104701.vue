<template>
  <div class="myCreated-Events-container">

     <div class="event-list">
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
      value: ['public']
    }
  },
  components: {
    EventItem,
  },

  computed: {
     events(){
       return this.$store.state.events
     },
   
    
  },

  methods: {
    async filterEvents() {
      if(this.value.in) {
          await this.$store.dispatch("fetchFilteredEvents", this.value)
      }
    }
  }


}
</script>

<style scoped>

</style>