module Adapter

open Move
open Files

type Repository = 
    abstract member FindAll : Shipper list
    abstract member Save : Shipper -> unit

type MyRepository() =
    member this.FindAll = (this :> Repository).FindAll
    member this.Save s = (this :> Repository).Save(s)

    interface Repository with
        member this.FindAll = List.empty<Shipper>
        member this.Save s = ()
