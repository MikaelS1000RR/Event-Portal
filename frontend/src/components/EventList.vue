<template>
  <div class="wrapper">
   <div class="event-list">
     <div class="event-card" 
     v-for="myEvent of events" 
     :key="myEvent.id"
     @click="redirect">
               <v-card :loading="loading" class="mx-auto my-12" max-width="374">
         <div class="access">
       <p>Public</p>
        </div>
         <v-img 
         class="event-img"
          height="200px"
          src="https://s24193.pcdn.co/wp-content/uploads/2017/06/Madilyn-Smith-Entity-Squidward1.png"
        >
          <v-card-title>
            <p>{{ myEvent.location }}</p>
            </v-card-title>
         </v-img>
        </v-card>

     </div>
   </div>
  </div>
</template>

<script>
export default {
  computed: {
    events() {
      return this.$store.state.events;
    },
  },
  created() {
    this.$store.dispatch("fetchEvents");
  },
  methods:{
    redirect(){
      
    }
  }
};
</script>

<style scoped>
.wrapper {
  width: 100%;

  display: flex;
  justify-content: center;
  align-items: center;
}

.event-list {
  width: 95%;
  height:100vh;
  padding-top:3vw;
  display: grid;
  grid-template-columns: repeat(3, 1fr);
 
  justify-content: center;


  position: relative;
}

.event-card {
   text-align: center;
   padding:1vw;
   height:75%;
   display:flex;
   align-items: center;
    transition: transform .2s; 
  
}

.event-card:hover{
  cursor: pointer;
  transform: scale(1.1);
 

}

.v-card__title{
  justify-content: center;
  font-weight: bold !important;
  margin-top:4vw;
  
}

.access{
  background-color: white;
  height:20px;

  
}

.event-img{

  text-align: center;

  
}
</style>
