<template>
  <div class="home">
    
  </div>
</template>

<script>
// @ is an alias to /src


export default {
  name: 'Home',
  components: {

  },

  data(){

    return{
      
    }
      
         
       
  },
  

  methods:
  {
    getEvents(){
      
       return this.$store.dispatch('fetchEvents')
    },

    getSpecEvent(){
      return this.$store.dispatch('fetchSpecEvent')
    },
    
  }
  
}
</script>

<style scoped>

  .home {

    width: 100%;
    height: 100vh;
     background-image: radial-gradient(at top left, black, transparent),
    radial-gradient(at top right, rgb(70, 0, 128), transparent),
    radial-gradient(at bottom left, #6133ed68, transparent);


  }
 
</style>
