namespace MathService

type Effect<'result> =
    | Log of string * (unit -> Effect<'result>)
    | Result of 'result