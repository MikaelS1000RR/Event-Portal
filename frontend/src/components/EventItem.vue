<template>
  
   <div class="event-card" 
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
            <p>{{ event.location }}</p>
            </v-card-title>
         </v-img>
        </v-card>

     </div>
</template>

<script>
export default {
props:['event'],

  methods:{
    redirect(){
      this.$router.push('/details/' + this.event.id)
    
    }
  }
}
</script>

<style scoped >

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