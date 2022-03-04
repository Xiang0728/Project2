<template>
  <v-app>
    
    <div class="head">
   
    </div>
    <div class="body">
      <v-row class="form">
        <v-col xl="4" cols="12">
        </v-col>
       
        <v-col xl="4" cols="12">
          <v-card class="form text-center">
            <v-card class="formtitle center text-h5">聯絡我們</v-card>
            <v-divider></v-divider>
          <v-form  >
            <v-container >

               <v-text-field
                v-model="name"
                         
                label="姓名"
                required
              ></v-text-field>

              <v-text-field
                v-model="email"
                :rules="emailRules"
                label="E-mail"
                required
              ></v-text-field>

  
    
            <v-textarea
              v-model="msg"
              name="input-7-1"
              label="請輸入內容"        
              hint="輸入中..."
            ></v-textarea>

              <v-btn 
                color=""
                @click="submit()"               
              >提交</v-btn>
            
            </v-container>
          </v-form>
          </v-card>
        </v-col>
        <v-col xl="4" cols="12">
        </v-col>

      </v-row>

        <v-overlay v-if="isSending">
          <v-progress-circular
            indeterminate
            color="red"
          ></v-progress-circular>
                   
        </v-overlay>
    
    </div>
  </v-app>
</template>

<script>
import {apiPostMail} from '../utils/request'

export default {
  name: 'Home',
  components: {
   
  },
   data () {
      return {
        email:'',
        msg:'',                
        name:'',
        isSending:false,
        emailRules: [
        v => !!v || 'E-mail is required',     
        ]
      }      
  },
  methods:{

    submit(){
      if(this.email==""||this.msg==""||this.name=="")
      {
        alert("輸入不可為空")
      }
      else
      {
        this.isSending=true
        apiPostMail(this.email,this.name,this.msg).then((res)=>
        {
          if(res.status==200)
          {
            alert("發送成功")
            this.isSending=false
            this.empty()
          }
          else
          {
            alert(res.data)
            this.isSending=false
            this.empty()
          }
          }).catch((ex)=>
          {
            alert("錯誤 : " +ex)
            this.isSending=false
            this.empty()
        })
      }
    },
    empty(){
      this.email=""
      this.msg=""
      this.name=""
    }


  }
}
</script>


<style scoped>
 .head{
    min-height: 15%;
   
  }
  .body{
    min-height: 70%;   
  }
  .form{ 
    min-height: 80%;
  }
  .formtitle{
    background-color: rgb(104, 127, 190) !important;
    color: white !important;
    min-height: 80px;
  }
  .center{
    display: flex;
    justify-content: center; 
    align-items: center; 
  }
 
</style>
