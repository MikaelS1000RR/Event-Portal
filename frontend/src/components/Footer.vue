<template>
  <div class="wrapper">
    <div class="footer">
    <div class="footer-info">
      <p>GESHDO Now AB</p>
      <span>Pildammsvägen 6B</span>
      <span>211 46 Malmö</span>
      <span>contact@geshdo.com</span>
    </div>
    </div>

  </div>
</template>

<script>
export default {

}
</script>

<style scoped>
  .wrapper{
    width:100vw;
   
    background-color: var(--grey);
  }

  .footer{
    width:100%;
    color:white;
    font-size:.8vw;
   display:flex;
   flex-direction: column;
   align-items: flex-start;
  }

  .footer-info{
    display:flex;
    flex-direction: column;
   /* padding-bottom:2vh;
    padding-left:4vw;*/
    padding:1vh 0 2vh 4vw;
  }

  .footer>span{
     display: block;
  }
</style>