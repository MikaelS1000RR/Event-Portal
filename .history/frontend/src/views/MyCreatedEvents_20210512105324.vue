<template>
  <div class="myCreated-Events-container">

     <div class="event-list" v-model="">
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
      value: ['private']
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
      if(this.value.incudels("private")) {
          await this.$store.dispatch("fetchFilteredEvents", this.value)
      }
    }
  }


}
</script>

<style scoped>

</style>